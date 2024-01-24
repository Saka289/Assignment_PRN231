using System.Text;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace WebAppAPI.CustomFormatter;

public class CsvOutputFormatter : TextOutputFormatter
{
    public CsvOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));

        // Thêm các định dạng mở rộng khác của CSV nếu cần
        SupportedEncodings.Add(Encoding.UTF8);
    }

    protected override bool CanWriteType(System.Type type)
    {
        // Kiểm tra nếu kiểu dữ liệu có thể được xuất ra CSV
        return typeof(IEnumerable<object>).IsAssignableFrom(type);
    }

    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();

        // Lấy dữ liệu từ đối tượng
        var data = context.Object as IEnumerable<object>;

        // Kiểm tra null hoặc không có dữ liệu
        if (data == null || !data.Any())
        {
            response.ContentLength = 0;
            return;
        }

        // Xác định loại đối tượng và lấy tên cột (header) từ các thuộc tính
        var type = data.First().GetType();
        var properties = type.GetProperties();

        // Tạo header
        buffer.AppendLine(string.Join(",", properties.Select(p => p.Name)));

        // Thêm dữ liệu từ các đối tượng
        foreach (var item in data)
        {
            buffer.AppendLine(string.Join(",", properties.Select(p => p.GetValue(item))));
        }

        // Ghi dữ liệu vào response
        await response.WriteAsync(buffer.ToString(), selectedEncoding);
    }
}