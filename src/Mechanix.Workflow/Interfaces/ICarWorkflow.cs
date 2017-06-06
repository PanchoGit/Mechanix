using Mechanix.Common;
using Mechanix.Domain;

namespace Mechanix.Workflow.Interfaces
{
    public interface ICarWorkflow
    {
        Result Create(Car car);
    }
}
