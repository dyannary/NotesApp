using Notes.Domain;

namespace Notes.Application.FactoryMethod;

public interface INoteFactory
{
    Entity Create();
}   