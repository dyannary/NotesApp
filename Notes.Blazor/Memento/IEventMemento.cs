namespace Notes.Blazor.Memento;

public interface IEventMemento
{
     EventOriginator GetState();
}