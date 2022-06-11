using System.Net;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TechTalk.SpecFlow.Assist;
using WAW.API.Employers.Domain.Models;
using WAW.API.Employers.Domain.Repositories;
using WAW.API.Employers.Resources;
using WAW.API.Shared.Domain.Repositories;
using WAW.API.Tests.Helpers;
using Xunit;

namespace WAW.API.Tests.Steps;

[Binding]
public class CompanySteps {
  private const string endpoint = "/api/v1/companies";
  private readonly WebApplicationFactory<Program> factory;
  private readonly ICompanyRepository repository;
  private readonly IUnitOfWork unitOfWork;
  private HttpClient client = null!;
  private HttpResponseMessage response = null!;
  private CompanyResource? entity;
  private IEnumerable<CompanyResource>? entities;

  public CompanySteps(
    WebApplicationFactory<Program> factory,
    ICompanyRepository repository,
    IUnitOfWork unitOfWork
  ) {
    this.factory = factory;
    this.repository = repository;
    this.unitOfWork = unitOfWork;
  }

  [Given(@"I am a Companies client")]
  public void GivenIAmACompaniesClient() {
    client = factory.CreateDefaultClient();
  }

  [Given(@"the Companies repository has data")]
  public async Task GivenTheCompaniesRepositoryHasData(Table table) {
    var entries = table.CreateSet<Company>();
    foreach (var entry in entries) {
      await repository.Add(entry);
      await unitOfWork.Complete();
    }
  }

  [When(@"a GET request is sent to Companies")]
  public async Task WhenAGetRequestIsSentToCompanies() {
    response = await client.GetAsync(endpoint);
  }

  [When(@"a POST request is sent to Companies")]
  public async Task WhenAPostRequestIsSentToCompanies(Table table) {
    var data = table.CreateInstance<CompanyRequest>();
    var json = JsonConvert.SerializeObject(data);
    var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
    response = await client.PostAsync(endpoint, content);
  }

  [When(@"a PUT request is sent to Companies with Id (.*)")]
  public async Task WhenAPutRequestIsSentToCompaniesWithId(int id, Table table) {
    var data = table.CreateInstance<CompanyRequest>();
    var json = JsonConvert.SerializeObject(data);
    var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
    response = await client.PutAsync($"{endpoint}/{id}", content);
  }

  [When(@"a DELETE request is sent to Companies with Id (.*)")]
  public async Task WhenADeleteRequestIsSentToCompaniesWithId(int id) {
    response = await client.DeleteAsync($"{endpoint}/{id}");
  }

  [Then(@"a CompanyResource response with status (.*) is received")]
  public void ThenACompanyResourceResponseWithStatusIsReceived(int status) {
    var expected = (HttpStatusCode) status;
    Assert.Equal(expected, response.StatusCode);
  }

  [Then(@"a list of CompanyResources is included in the body")]
  public async Task ThenAListOfCompanyResourcesIsIncludedInTheBody(Table table) {
    entities = await response.Content.ReadFromJsonAsync<List<CompanyResource>>();
    table.CompareToSet(entities);
  }

  [Then(@"a CompanyResource is included in the body")]
  public async Task ThenACompanyResourceIsIncludedInTheBody(Table table) {
    entity = await response.Content.ReadFromJsonAsync<CompanyResource>();
    table.CompareToInstance(entity);
  }

  [Then(@"a CompanyResource Error Message is included in the body")]
  public async Task ThenACompanyResourceErrorMessageIsIncludedInTheBody(Table table) {
    var text = await response.Content.ReadAsStringAsync();
    var error = table.CreateInstance<TextError>();
    Assert.Contains(error.Message, text);
  }
}
