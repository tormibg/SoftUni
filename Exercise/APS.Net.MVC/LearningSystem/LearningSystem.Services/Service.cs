using LearningSystem.Data;

namespace LearningSystem.Services
{
	public abstract class Service
	{
		protected Service()
		{
			this.Contex = new LearningSystemContext();
		}

		protected LearningSystemContext Contex { get; }
	}
}
