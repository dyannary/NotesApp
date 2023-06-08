namespace Notes.Blazor.Services.Implementations;

public class DateStateService
{
    private DateTime _selectedDate = DateTime.Today;

    public DateTime? SelectedDate
    {
        get => _selectedDate;
        set
        {
            _selectedDate = value.Value;
            OnSelectedDateChanged?.Invoke(_selectedDate);
        }
    }

    public event Action<DateTime> OnSelectedDateChanged;
}