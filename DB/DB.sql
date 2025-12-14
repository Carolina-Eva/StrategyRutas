CREATE TABLE RutaCalculada
(
    Id INT IDENTITY(1,1) PRIMARY KEY,

    OrigenX INT NOT NULL,
    OrigenY INT NOT NULL,
    DestinoX INT NOT NULL,
    DestinoY INT NOT NULL,

    Estrategia NVARCHAR(50) NOT NULL,

    DistanciaTotal INT NOT NULL,
    TraficoTotal INT NOT NULL,
    RiesgoTotal INT NOT NULL,
    PesoFinal INT NOT NULL,

    Fecha DATETIME NOT NULL
);


CREATE PROCEDURE GUARDAR_RUTA
(
    @DistanciaTotal INT,
    @TraficoTotal INT,
    @RiesgoTotal INT,
    @PesoFinal INT,

    @OrigenY INT,
    @OrigenX INT,
    @DestinoY INT,
    @DestinoX INT,

    @Estrategia NVARCHAR(50),
    @Fecha DATETIME
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO RutaCalculada
    (
        DistanciaTotal,
        TraficoTotal,
        RiesgoTotal,
        PesoFinal,
        OrigenY,
        OrigenX,
        DestinoY,
        DestinoX,
        Estrategia,
        Fecha
    )
    VALUES
    (
        @DistanciaTotal,
        @TraficoTotal,
        @RiesgoTotal,
        @PesoFinal,
        @OrigenY,
        @OrigenX,
        @DestinoY,
        @DestinoX,
        @Estrategia,
        @Fecha
    );
END;


CREATE PROCEDURE OBTENER_RUTAS
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        OrigenX,
        OrigenY,
        DestinoX,
        DestinoY,
        Estrategia,
        DistanciaTotal,
        TraficoTotal,
        RiesgoTotal,
        PesoFinal,
        Fecha
    FROM RutaCalculada
    ORDER BY Fecha DESC;
END;
