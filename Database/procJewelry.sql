-- Thêm mới công ty --
create proc ADD_CT
@id varchar(10),
@name nvarchar(50)
AS
BEGIN
	INSERT INTO company(id,name)
	VALUES(@id, @name)
END
-- Thêm mới loại sp --
create proc ADD_TYPE
@id varchar(10),
@name nvarchar(50)
AS
BEGIN
	INSERT INTO type(id,name)
	VALUES(@id, @name)
END
-- Sửa thông tin công ty --
create proc UPDATE_CT
@firstid varchar(10),
@id varchar(10),
@name nvarchar(50)
AS
BEGIN
	UPDATE company SET  name = @name
	WHERE id = @firstid
END
-- Sửa thông tin loại sản phẩm --
create proc UPDATE_TYPE
@firstid varchar(10),
@id varchar(10),
@name nvarchar(50)
AS
BEGIN
	UPDATE type SET  name = @name
	WHERE id = @firstid
END

-- Xóa thông tin công ty --
create proc DELETE_CT
@id varchar(10)
AS
BEGIN
	DELETE FROM company WHERE id=@id
END

-- Xóa thông tin loại sản phẩm --
create proc DELETE_TYPE
@id varchar(10)
AS
BEGIN
	DELETE FROM type WHERE id=@id
END