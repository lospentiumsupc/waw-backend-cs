Feature: Companies API
As a developer
I want to manage Companies through an API
In order to make it available for client applications.

  Scenario: Get all Companies
    Given I am a client
    And the repository has data
      | Id | Name        | Address      | Email           |
      | 1  | Google Inc. | Lima, PE     | google@fake.com |
      | 2  | Meta Inc.   | Santiago, CH | meta@fake.com   |
    When a GET request is sent
    Then a response with status 200 is received
    And a list of Company resources is included in the body.
      | Id | Name        | Address      | Email           |
      | 1  | Google Inc. | Lima, PE     | google@fake.com |
      | 2  | Meta Inc.   | Santiago, CH | meta@fake.com   |

  Scenario: Add Company with data
    Given I am a client
    And the repository has data
      | Id | Name        | Address      | Email           |
      | 1  | Google Inc. | Lima, PE     | google@fake.com |
      | 2  | Meta Inc.   | Santiago, CH | meta@fake.com   |
    When a POST request is sent
      | Name   | Address          | Email           |
      | Oracle | Buenos Aires, AR | oracle@fake.com |
    Then a response with status 201 is received
    And a Company resource is included in the body
      | Id | Name   | Address          | Email           |
      | 3  | Oracle | Buenos Aires, AR | oracle@fake.com |

  Scenario: Add invalid Company
    Given I am a client
    When an invalid POST request is sent
      | Name | Address   | Email            |
      |      | Quito, EC | company@fake.com |
    Then a response with status 400 is received
    And a Error Message is included in the body
      | Message                                                     |
      | An error occurred while saving the company: {error.Message} |

  Scenario: Update existing Company
    Given I am a client
    When a PUT request is sent
      | Name        | Address    | Email              |
      | Google Inc. | Huacho, PE | newgoogle@fake.com |
    Then a response with status 200 is received
    And a the updated Company resource is included in the body
      | Id | Name        | Address    | Email              |
      | 1  | Google Inc. | Huacho, PE | newgoogle@fake.com |

  Scenario: Delete existing Company
    Given I am a client
    When a DELETE request is sent
      | Request | Endpoint          |
      | DELETE  | /api/v1/company/3 |
    Then a response with status 200 is received
    And a the selected Company is removed from the repository
      | Id | Name        | Address    | Email              |
      | 1  | Google Inc. | Huacho, PE | newgoogle@fake.com |
    And the removed Company resource is included in the body
      | Id | Name   | Address          | Email           |
      | 3  | Oracle | Buenos Aires, AR | oracle@fake.com |
