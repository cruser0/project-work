namespace Winform
{
    public interface ICalls<T>
    {
        //ICollection<T> GetAll();
        //T GetById(int id);
        T Create(T entity);
        T Update(int id, T entity);
        T Delete(int id);
    }
}
