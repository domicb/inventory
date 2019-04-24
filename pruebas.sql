SELECT *
FROM `mydb`.`client`;

SELECT *
FROM `mydb`.`subproduct`;

SELECT *
FROM `mydb`.`tipoproducto` order by `tipo`;

DELETE FROM `mydb`.`tipoproducto`
WHERE `idtipoProducto` = 39



/*UPDATE `mydb`.`tipoproducto`
SET
`tipo` = "Cola Gambón Mozambique" where `idtipoProducto` = 28;*/

/*UPDATE `mydb`.`subproduct`
SET
`size` = "Gamba G3B" where `idsubProduct` = 207;*/

SELECT *
FROM `mydb`.`subproduct` where `size` = 'Gamba G3B';

/*DELETE FROM `mydb`.`subproduct`
WHERE `idsubProduct` = 228; /*> 669 AND  `idsubProduct` < 681;

SELECT *
FROM `mydb`.`invoice`;

SELECT *
FROM `mydb`.`invoice_has_product`;


