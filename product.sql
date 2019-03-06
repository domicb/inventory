INSERT INTO `mydb`.`product`
(
`name`,
`size`,
`quantity`,
`dateIn`,
`dateOut`,
`kg`,
`price`)
VALUES
(
"Huevo Choco",
"default",
80,
curdate(),
curdate(),
1.300,
22);

INSERT INTO `mydb`.`product`
(
`name`,
`size`,
`quantity`,
`dateIn`,
`dateOut`,
`kg`,
`price`)
VALUES
(
"Gamba Blanca",
"default",
-1,
curdate(),
curdate(),
-1,
-1);

SELECT *
FROM `mydb`.`subproduct` where `product_idproduct` = 1;


SELECT *
FROM `mydb`.`product`


