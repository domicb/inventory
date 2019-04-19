CREATE TABLE `client` (
  `idclient` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `tlf` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `dni` varchar(45) DEFAULT NULL,
  `direccion` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`idclient`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;


CREATE TABLE `invoice` (
  `idinvoice` int(11) NOT NULL AUTO_INCREMENT,
  `dateCreate` date DEFAULT NULL,
  `amount` double DEFAULT NULL,
  `client_idclient` int(11) NOT NULL,
  PRIMARY KEY (`idinvoice`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;


CREATE TABLE `invoice_has_product` (
  `invoice_idinvoice` int(11) NOT NULL,
  `id_subproduct` int(11) NOT NULL,
  `priceProduct` varchar(45) NOT NULL,
  `cantidad` varchar(45) NOT NULL,
  `peso` varchar(45) NOT NULL,
  `total` varchar(45) NOT NULL,
  PRIMARY KEY (`invoice_idinvoice`,`id_subproduct`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
