ALTER TRIGGER CHANGE_PB_INSERT
ON PhongBan
FOR INSERT,UPDATE
AS
BEGIN 
	UPDATE NhanVien
	SET IdPB = (SELECT inserted.IdPB FROM inserted)			/* Đổi Phòng Ban cho Nhân Viên*/
	WHERE IdNV IN (SELECT inserted.IdTP FROM inserted)		/* Sau khi Nhân Viên được chọn làm trưởng phòng cho PB mới*/
END