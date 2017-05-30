/* UPDATE lại ngày công sau khi thêm hoặc xóa trong chi tiết ngày công của Nhân Viên */
/* Điều kiện đc lấy theo IdChamCong */


CREATE TRIGGER UPDATE_NGAYCONG
ON ChiTietNgayCong
FOR INSERT,UPDATE,DELETE
AS
BEGIN 
		UPDATE ChamCong
		SET NgayCong = (SELECT COUNT(*) FROM ChiTietNgayCong 
						WHERE (IdChamCong = (SELECT inserted.IdChamCong FROM inserted) AND DiLam = 0) OR (IdChamCong = (SELECT deleted.IdChamCong FROM deleted) AND DiLam = 0))
		WHERE IdChamCong = (SELECT inserted.IdChamCong FROM inserted) OR IdChamCong = (SELECT deleted.IdChamCong FROM deleted)
END