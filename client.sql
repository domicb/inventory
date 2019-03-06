INSERT INTO `mydb`.`client`
(
`name`,
`tlf`,
`email`)
VALUES
( 
"julian",
"603781644",
"julian@gmail.com");

SELECT `client`.`idclient`,
    `client`.`name`,
    `client`.`tlf`,
    `client`.`email`
FROM `mydb`.`client`;
