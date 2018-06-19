# module-1-capstone
Creates a console based vending machine application

Created with Nabiel through Pair Programming
for the Summer Cohort of Tech Elevator in June 2018

Repo originally hosted on BitBucket
https://bitbucket.org/te-cle-cohort-8/c-module-1-capstone-team-0/src/master/ 

**The requirements for the application are listed below:**

1. The vending machine needs to dispense beverages, candy, chips, and gum.
    a. Each vending machine item has a Name and a Price.
2. A main menu should display when the software is run presenting the following options:
```
(1) Display Vending Machine Items
(2) Purchase
```
3. Vending machine inventory is stocked via an input file.
4. The vending machine is automatically restocked each time the application runs.
5. When the customer selects (1) Display Vending Machine Items they are presented a list of all items in the vending machine with its quantity remaining.
    a. Each vending machine product has a slot identifier and a purchase price.
    b. Each slot in the vending machine has enough room for 5 of that product.
    c. Every product is initially stocked to the maximum amount.
    d. A product which has run out should indicate it is SOLD OUT.

6. When the customer selects (2) Purchase they are guided through the purchasing process menu:
```
(1) Feed Money
(2) Select Product
(3) Finish Transaction
Current Money Provided: $2.00
```

7. The purchase process flow is as follows
    a. Selecting (1) Feed Money A customer can repeatedly feed money into the machine in whole dollar amounts (e.g. $1, $2, $5, $10).
        i. The Current Money Provided indicates how much money the customer has fed into the machine.
    b. Selecting (2) Select Product allows the customer to select a product to purchase.
        i. If the product code does not exist, the customer is informed and returned to the Purchase menu.
        ii. If a product is sold out, the customer is informed and returned to the Purchase menu.
        iii. If a valid product is selected it is dispensed to the customer.
        iv. After the product is dispensed, the machine should update its balance accordingly and return the customer to the Purchase menu.

8.  All purchases must be audited to prevent theft from the vending machine
    a.  Each purchase should generate a line in a file called Log.txt
    b.  The audit entry should be in the format

    ```
    01/01/2016 12:00:00 PM FEED MONEY:  $5.00      $5.00
    01/01/2016 12:00:00 PM FEED MONEY:  $5.00      $10.00
    01/01/2016 12:00:00 PM Crunchie B4  $10.00     $8.50
    01/01/2016 12:00:00 PM Cowtales     $8.50      $7.50
    01/01/2016 12:00:00 PM GIVE CHANGE: $7.50      $0.00
    ```