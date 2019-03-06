
INSERT INTO `mydb`.`invoice`
(
`dateCreate`,
`amount`,
`client_idclient`)
VALUES
(
curdate(),
130,
1
);

SELECT *
FROM `mydb`.`invoice`;

SELECT *
FROM `mydb`.`invoice_has_product`;


/*dame los productos cuya id de factura es*/
SELECT *
FROM `mydb`.`product` where `idproduct` IN (
	select `product_idproduct` from `mydb`.`invoice_has_product` where `invoice_idinvoice` = 2
    );


INSERT INTO `mydb`.`invoice_has_product`
(`invoice_idinvoice`,
`product_idproduct`)
VALUES
(2,
1);







