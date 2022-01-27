namespace CleanCode.Academy.Core.CreateOrder;

using System.Threading.Tasks;

public interface IModifier
{
    Task Save(Order order);
}
