CREATE DATABASE kfc_practica;

CREATE TABLE Categorias (
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(80) NOT NULL
);

CREATE TABLE Productos (
    Id SERIAL PRIMARY KEY,
    CategoriaId INT NOT NULL,
    Nombre VARCHAR(120) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Disponible BOOLEAN DEFAULT TRUE,

    CONSTRAINT FK_Producto_Categoria
        FOREIGN KEY (CategoriaId)
        REFERENCES Categorias(Id)
);

CREATE TABLE Usuarios (
    Id SERIAL PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Email VARCHAR(150) UNIQUE NOT NULL,
    Telefono VARCHAR(20),
    FechaRegistro DATE NOT NULL
);

CREATE TABLE Direcciones (
    Id SERIAL PRIMARY KEY,
    UsuarioId INT NOT NULL,
    Ciudad VARCHAR(80),
    Sector VARCHAR(100),
    CallePrincipal VARCHAR(120),
    Referencia TEXT,

    CONSTRAINT FK_Direccion_Usuario
        FOREIGN KEY (UsuarioId)
        REFERENCES Usuarios(Id)
);

CREATE TABLE Pedidos (
    Id SERIAL PRIMARY KEY,
    UsuarioId INT NOT NULL,
    Fecha TIMESTAMP NOT NULL,
    Estado VARCHAR(30),
    Total DECIMAL(10,2),

    CONSTRAINT FK_Pedido_Usuario
        FOREIGN KEY (UsuarioId)
        REFERENCES Usuarios(Id)
);

CREATE TABLE DetallePedido (
    Id SERIAL PRIMARY KEY,
    PedidoId INT NOT NULL,
    ProductoId INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,

    CONSTRAINT FK_Detalle_Pedido
        FOREIGN KEY (PedidoId)
        REFERENCES Pedidos(Id),

    CONSTRAINT FK_Detalle_Producto
        FOREIGN KEY (ProductoId)
        REFERENCES Productos(Id)
);

INSERT INTO Categorias (Nombre) VALUES
('Combos'),
('Hamburguesas'),
('Pollo'),
('Bebidas'),
('Postres');

INSERT INTO Productos (CategoriaId,Nombre,Precio) VALUES
(1,'Mega Combo Familiar',29.99),
(1,'Combo Personal',11.99),
(2,'Zinger Burger',7.50),
(2,'BBQ Burger',8.20),
(3,'Bucket 8 piezas',18.50),
(3,'Hot Wings x6',9.80),
(3,'Chicken Popcorn',6.40),
(4,'Pepsi 500ml',2.00),
(4,'Mirinda',2.00),
(4,'Agua',1.50),
(5,'Helado Sundae',3.20),
(5,'Pie de Manzana',2.80);

INSERT INTO Usuarios
(Nombre,Apellido,Email,Telefono,FechaRegistro)
VALUES
('Juan','Perez','juan@correo.com','099111111','2025-01-10'),
('Maria','Lopez','maria@correo.com','099222222','2025-02-18'),
('Carlos','Ramirez','carlos@correo.com','099333333','2025-03-01'),
('Ana','Mendoza','ana@correo.com','099444444','2025-03-20'),
('Luis','Suarez','luis@correo.com','099555555','2025-04-12');

INSERT INTO Direcciones
(UsuarioId,Ciudad,Sector,CallePrincipal,Referencia)
VALUES
(1,'Quito','Carcelén','Av. Galo Plaza','Frente al parque'),
(1,'Quito','Calderón','Av. Giovanni','Casa azul'),

(2,'Quito','La Carolina','Av. Naciones Unidas','Edificio Torre'),

(3,'Quito','El Condado','Av. Occidental','Junto al Supermaxi'),

(4,'Quito','Solanda','Av. Ajaví','Frente al mercado'),

(5,'Quito','Cumbayá','Interoceánica','Urbanización');



INSERT INTO Pedidos
(UsuarioId,Fecha,Estado,Total)
VALUES

(1,'2025-05-01 12:10','Entregado',21.50),
(1,'2025-05-08 18:30','Entregado',33.00),
(1,'2025-06-10 13:20','Preparando',18.70),

(2,'2025-05-10 14:15','Entregado',9.50),
(2,'2025-06-01 19:00','Cancelado',15.40),

(3,'2025-06-15 12:30','Entregado',42.20),
(3,'2025-06-20 20:10','Pendiente',18.90),
(3,'2025-06-28 16:00','Entregado',12.50),

(4,'2025-06-25 18:00','Preparando',17.00),

(5,'2025-07-01 12:30','Entregado',28.30),
(5,'2025-07-03 19:45','Entregado',11.20),
(5,'2025-07-04 15:20','Pendiente',8.00),
(5,'2025-07-08 18:30','Entregado',39.80);


INSERT INTO DetallePedido
(PedidoId,ProductoId,Cantidad,PrecioUnitario)
VALUES

(1,3,2,7.50),
(1,8,1,2.00),
(1,11,1,3.20),

(2,5,1,18.50),
(2,8,2,2.00),
(2,12,1,2.80),

(3,6,1,9.80),
(3,10,2,1.50),
(3,11,1,3.20),

(4,3,1,7.50),
(4,8,1,2.00),

(5,5,1,18.50),

(6,1,1,29.99),
(6,8,2,2.00),
(6,11,1,3.20),
(6,12,1,2.80),

(7,7,2,6.40),
(7,10,1,1.50),

(8,2,1,11.99),
(8,9,1,2.00),

(9,3,2,7.50),
(9,10,1,1.50),

(10,5,1,18.50),
(10,11,2,3.20),

(11,4,1,8.20),
(11,8,1,2.00),

(12,3,1,7.50),
(12,10,1,1.50),

(13,1,1,29.99),
(13,6,1,9.80),
(13,8,1,2.00);