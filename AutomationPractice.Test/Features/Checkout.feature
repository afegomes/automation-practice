Feature: Checkout
	In order to save time
	As a customer
	I want to buy clothing on-line

Scenario: Buy top selling products
	Given a 'Best sellers' category
	When I add its products to my shopping cart
	Then I should be able to check them out

Scenario: Save top selling products
	Given a 'Best sellers' category
	When I add its products to my shopping cart
	Then I should be able to keep a list of them
