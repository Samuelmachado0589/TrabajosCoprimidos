
CREATE TRIGGER sp_actualizarEstado_Mesa
ON Reservas
AFTER INSERT
AS
BEGIN
    UPDATE Mesa
    SET Estado_Mesa = 'NO'
    WHERE ID_Mesa = (SELECT ID_Mesa FROM inserted)
END;

SELECT * FROM Comentarios;

CREATE PROCEDURE SP_Comentario
@ID_Reserva INT, 
@Comentario NVARCHAR(100), 
@Fecha_Comentario DATETIME, 
@AUX VARCHAR (1) ,
@ID_Comentario int 
AS 
IF @AUX = 'I' 
BEGIN 
INSERT INTO Comentarios(ID_Reserva, Comentario, Fecha_Comentario) 
VALUES (@ID_Reserva, @Comentario, @Fecha_Comentario); 
END 
IF @AUX = 'U' 
BEGIN 
UPDATE Comentarios 
SET Comentario= @Comentario, Fecha_Comentario= @Fecha_Comentario 
WHERE ID_Reserva=@ID_Reserva 
END 
IF @AUX = 'D' 
BEGIN 
delete Comentarios where  ID_Comentario=@ID_Comentario
END

