namespace SportStore.Models
{
    // Модель представления для отображения информации об ошибке
    public class ErrorViewModel
    {
        // Идентификатор запроса
        public string? RequestId { get; set; }

        // Метод, указывающий наличие идентификатора запроса
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

