CREATE TRIGGER UPDATE_NGAYCONG_CHAMCONG
ON ChiTietNgayCong
FOR INSERT,UPDATE
AS
BEGIN 
	IF((SELECT inserted.DiLam FROM inserted) = 0)
		UPDATE ChamCong
		SET NgayCong = NgayCong + 1
		WHERE IdChamCong = (SELECT inserted.IdChamCong FROM inserted)
END