SELECT *
FROM `mydb`.`client`;

SELECT *
FROM `mydb`.`product`;

SELECT `dateOut`
FROM `mydb`.`subproduct` where `idsubProduct`=700;

SELECT *
FROM `mydb`.`tipoproducto` order by `tipo`;

/*DELETE FROM `mydb`.`tipoproducto`
WHERE `idtipoProducto` = 7*/


/*UPDATE `mydb`.`tipoproducto`
SET
`tipo` = "Cola Gambón Mozambique" where `idtipoProducto` = 28;*/

/*UPDATE `mydb`.`subproduct`
SET
`price` = 40 where `idsubProduct` = 704;*/

SELECT *
FROM `mydb`.`subproduct` where `tipoProducto_idtipoProducto` = 32;

/*DELETE FROM `mydb`.`subproduct`
WHERE `idsubProduct` = 267; /*> 669 AND  `idsubProduct` < 681;

SELECT *
FROM `mydb`.`invoice`;

SELECT *
FROM `mydb`.`invoice_has_product`;


