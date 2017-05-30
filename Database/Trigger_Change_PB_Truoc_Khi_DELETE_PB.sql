ALTER TRIGGER CHANGE_PB
ON PhongBan
INSTEAD OF DELETE     /* INSTEAD OF: Thực thi trước khi lưu vào Database*/
AS
BEGIN 
	UPDATE NhanVien
	SET IdPB = 1											/* Đổi PB của Nhân Viên sang Chưa thuộc PB nào */
	WHERE IdPB IN (SELECT deleted.IdPB FROM deleted)		/* Tất cả các nhân viên thuộc phòng ban bị xóa sẽ bị chuyển */
	DELETE FROM PhongBan WHERE IdPB = (SELECT deleted.IdPB FROM deleted)
END