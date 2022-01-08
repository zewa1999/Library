Feature: Repository tests

Scenario Outline: Insert data into repositories
	Given I want to insert data into the <RepositoryType>
	When I call the Insert method
	Then I should have a valid result
		| RepositoryType       |
		| AccountRepository    |
		| AuthorRepository     |
		| BookRepository       |
		| BorrowerRepository   |
		| BorrowRepository     |
		| DomainRepository     |
		| EditionRepository    |
		| LibrarianRepository  |
		| PropertiesRepository |

Scenario Outline: Update data from the repositories
	Given I want to update data from the <RepositoryType>
	When I call the Update method
	Then I should have a valid result
		| RepositoryType       |
		| AccountRepository    |
		| AuthorRepository     |
		| BookRepository       |
		| BorrowerRepository   |
		| BorrowRepository     |
		| DomainRepository     |
		| EditionRepository    |
		| LibrarianRepository  |
		| PropertiesRepository |

Scenario Outline: Get data by ID from the repositories
	Given I want to get data from the <RepositoryType> with the Id 1
	And The Id is valid
	When I call the GetByID method
	Then I should have a valid result
		| RepositoryType       |
		| AccountRepository    |
		| AuthorRepository     |
		| BookRepository       |
		| BorrowerRepository   |
		| BorrowRepository     |
		| DomainRepository     |
		| EditionRepository    |
		| LibrarianRepository  |
		| PropertiesRepository |

Scenario Outline: Get all data from the repositories with id
	Given I want to get all data from the <RepositoryType>
	When I call the Get method
	Then I should have a valid result
		| RepositoryType       |
		| AccountRepository    |
		| AuthorRepository     |
		| BookRepository       |
		| BorrowerRepository   |
		| BorrowRepository     |
		| DomainRepository     |
		| EditionRepository    |
		| LibrarianRepository  |
		| PropertiesRepository |

Scenario Outline: Delete data from the repositories
	Given I want to delete data from the <RepositoryType>
	And I create an object to delete
	When I call the Delete method
	Then I should have a valid result
		| RepositoryType       |
		| AccountRepository    |
		| AuthorRepository     |
		| BookRepository       |
		| BorrowerRepository   |
		| BorrowRepository     |
		| DomainRepository     |
		| EditionRepository    |
		| LibrarianRepository  |
		| PropertiesRepository |

Scenario Outline: Delete data from the repositories with a given id
	Given I want to delete data from the <RepositoryType>
	And I create an object to delete
	When I call the Delete method for the object with the id that I created
	Then I should have a valid result
		| RepositoryType       |
		| AccountRepository    |
		| AuthorRepository     |
		| BookRepository       |
		| BorrowerRepository   |
		| BorrowRepository     |
		| DomainRepository     |
		| EditionRepository    |
		| LibrarianRepository  |
		| PropertiesRepository |