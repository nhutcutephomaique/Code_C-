using System;
using System.IO;

public class TempFileManager : IDisposable
{
    private readonly string _filePath;

    private bool _disposed = false;

    public TempFileManager()
    {
        _filePath = Path.GetTempFileName();
        Console.WriteLine($"[Khởi tạo] Đã tạo file tạm tại: {_filePath}");
    }

    public void WriteData(string data)
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(TempFileManager), "Không thể ghi vào file đã bị hủy.");

        File.AppendAllText(_filePath, data + Environment.NewLine);
        Console.WriteLine($"[Ghi] Đã ghi dữ liệu: '{data}'");
    }

    public string ReadData()
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(TempFileManager), "Không thể đọc file đã bị hủy.");

        return File.ReadAllText(_filePath);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {

        }

        try
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
                Console.WriteLine($"[Dọn dẹp] Đã xóa file tạm thành công.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Lỗi] Không thể xóa file: {ex.Message}");
        }

        _disposed = true;
    }

    ~TempFileManager()
    {
        Console.WriteLine("[Finalizer] Người dùng quên gọi Dispose! GC đang dọn dẹp hộ...");
        Dispose(false);
    }
}