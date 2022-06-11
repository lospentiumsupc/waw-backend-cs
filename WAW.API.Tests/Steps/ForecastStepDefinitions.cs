using System.Net;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TechTalk.SpecFlow.Assist;
using WAW.API.Job.Resources;
using WAW.API.Weather.Domain.Models;
using WAW.API.Weather.Domain.Repositories;
using WAW.API.Weather.Resources;
using Xunit;

namespace WAW.API.Tests.Steps;

[Binding]
public class ForecastStepDefinitions {
  private const string endpoint = "api/v1/forecast";
  private const string secondendpoint = "api/v1/offer";
  private readonly WebApplicationFactory<Program> factory;
  private readonly IForecastRepository repository;
  private readonly IUnitOfWork unitOfWork;
  private HttpClient client = null!;
  private HttpResponseMessage response = null!;
  private ForecastResource? entity;
  private OfferResource? offer;
  private IEnumerable<ForecastResource>? entities;
  private IEnumerable<OfferResource>? offers;
  public ForecastStepDefinitions(
    WebApplicationFactory<Program> factory,
    IForecastRepository repository,
    IUnitOfWork unitOfWork
  ) {
    this.factory = factory;
    this.repository = repository;
    this.unitOfWork = unitOfWork;
  }

  [Given(@"I am a client")]
  public void GivenIAmAClient() {
    client = factory.CreateDefaultClient();
  }

  [Given(@"the repository has data")]
  public async Task GivenTheRepositoryHasData(Table table) {
    var entries = table.CreateSet<Forecast>();
    foreach (var entry in entries) {
      await repository.Add(entry);
      await unitOfWork.Complete();
    }
  }

  [When(@"a GET request is sent")]
  public async Task WhenAGetRequestIsSent() {
    response = await client.GetAsync(endpoint);
  }

  [When(@"a POST request is sent")]
  public async Task WhenAPostRequestIsSent(Table table) {
    var data = table.CreateInstance<ForecastRequest>();
    var json = JsonConvert.SerializeObject(data);
    var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
    response = await client.PostAsync(endpoint, content);
  }

  [Then(@"a response with status (.*) is received")]
  public void ThenAResponseWithStatusIsReceived(int status) {
    var expected = (HttpStatusCode) status;
    Assert.Equal(expected, response.StatusCode);
  }

  [Then(@"a list of Forecast resources is included in the body")]
  public async Task ThenAListOfForecastResourcesIsIncludedInTheBody(Table table) {
    entities = await response.Content.ReadFromJsonAsync<List<ForecastResource>>();
    table.CompareToSet(entities);
  }

  [Then(@"a Forecast resource is included in the body")]
  public async Task ThenAForecastResourceIsIncludedInTheBody(Table table) {
    entity = await response.Content.ReadFromJsonAsync<ForecastResource>();
    table.CompareToInstance(entity);
  }

  [Then(@"a list of Offer resources is included in the body")]
  public async Task ThenAListOfOfferResourcesIsIncludedInTheBody(Table table) {
    offers = await response.Content.ReadFromJsonAsync<List<OfferResource>>();
    table.CompareToSet(offers);
  }

  [Then(@"a Offer resource is included in the body")]
  public async Task ThenAOfferResourceIsIncludedInTheBody(Table table) {
    offer = await response.Content.ReadFromJsonAsync<OfferResource>();
    table.CompareToInstance(offer);
  }

  [When(@"a POST offer request is sent")]
  public async Task WhenApostOfferRequestIsSent(Table table) {
    var data = table.CreateInstance<OfferRequest>();
    var json = JsonConvert.SerializeObject(data);
    var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
    response = await client.PostAsync(secondendpoint, content);
  }


  [When(@"an invalid POST request is sent")]
  public void WhenAnInvalidPostRequestIsSent(Table table) {
    ScenarioContext.StepIsPending();
  }


  [Then(@"a Error Message is included in the body")]
  public void ThenAErrorMessageIsIncludedInTheBody(Table table) {
    ScenarioContext.StepIsPending();
  }

  [When(@"a PUT request is sent")]
  public void WhenAputRequestIsSent(Table table) {
    ScenarioContext.StepIsPending();
  }

  [Then(@"a the updated Offer resource is included in the body")]
  public void ThenATheUpdatedOfferResourceIsIncludedInTheBody(Table table) {
    ScenarioContext.StepIsPending();
  }

  [When(@"a DELETE request is sent")]
  public void WhenAdeleteRequestIsSent(Table table) {
    ScenarioContext.StepIsPending();
  }

  [Then(@"the removed Offer resource is included in the body")]
  public void ThenTheRemovedOfferResourceIsIncludedInTheBody(Table table) {
    ScenarioContext.StepIsPending();
  }

  [Then(@"a the selected Offer is removed from the repository")]
  public void ThenATheSelectedOfferIsRemovedFromTheRepository(Table table) {
    ScenarioContext.StepIsPending();
  }
}
