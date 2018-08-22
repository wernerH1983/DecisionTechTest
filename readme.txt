This Solution contains 3 projects:
* ShoppingBasket: class libary with domain logic
* ShoppingBasket.Web: basic mvc app, using the shoppingbasketlogic
* ShoppingBasketTests: Xunit Test Project

=============================================================
Steps taken:
Building ShoppingBasket Domain Libary
-focus first on developing basic Basket logic
 	-Adding product to the basket
	-calculation of the total price
-Adding logic for the discount offers
	-assuming every offer can be descriped as a minimal ammount of products to purchase and a discount ammount
	-adding support to apply multiple times same discount
-Create very basic mvc site to show usage of basket
	-using mocks for product/offer repository 
	-area of improvement would be adding interfaces for Offer and product repository, so this can be swapped for real services



