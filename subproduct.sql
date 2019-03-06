INSERT INTO `mydb`.`subproduct`
(
`name`,
`size`,
`product_idproduct`,
`kg`,
`quantity`,
`price`,
`dateIn`,
`dateOut`)
VALUES
(
"Gamba Blanca 100 piezas",
"100 piezas",
1,
1.100,
25,
22,
curdate(),
curdate()
),
(
"Gamba Blanca 80 piezas",
"80 piezas",
1,
1.200,
35,
28,
curdate(),
curdate()
);

SELECt *
FROM `mydb`.`subproduct`;

SELECT * FROM `mydb`.`subproduct` WHERE `name` LIKE "%Gamba Blanca%"

/*
DELETE FROM `mydb`.`subproduct`
WHERE `idsubProduct`>0;



