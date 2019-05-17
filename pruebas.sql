SELECT *
FROM `mydb`.`client` order by `name`;

UPDATE `mydb`.`client`
SET
`tlf` = '626954457'
WHERE `idclient` = 48;

SELECT *
FROM `mydb`.`product`;

SELECT `SIZE`, `PRICE`
FROM `mydb`.`subproduct`

SELECT `dateOut`
FROM `mydb`.`subproduct` where `idsubProduct`=700;

SELECT *
FROM `mydb`.`tipoproducto` order by `tipo`;

/*DELETE FROM `mydb`.`tipoproducto`
WHERE `idtipoProducto` = 36*/


/*UPDATE `mydb`.`tipoproducto`
SET
`tipo` = "Cola Gambón Mozambique" where `idtipoProducto` = 28;*/

/*UPDATE `mydb`.`subproduct`
SET
`kg` = 6 where `idsubProduct` = 751;*/

SELECT *
FROM `mydb`.`subproduct` order by `size` where `tipoProducto_idtipoProducto` = 757;

/*DELETE FROM `mydb`.`subproduct`
WHERE `idsubProduct` = 267; /*> 669 AND  `idsubProduct` < 681;

SELECT sum(amount)
FROM `mydb`.`invoice` where `client_idclient` <> 3;

SELECT *
FROM `mydb`.`invoice_has_product`;

SELECT *
FROM `mydb`.`invoice`;

SELECT *
FROM `mydb`.`invoice_has_product`;




