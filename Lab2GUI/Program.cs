using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab2GUI;
using Model;
using Model.Service;
using Model.Entities;
using Presentation;
using DataLayer;
using Ninject;
using System.Threading;

namespace Lab2GUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Ninject.StandardKernel kernel = new StandardKernel();
            kernel.Bind<ApplicationContext>().ToConstant(new ApplicationContext());
            kernel.Bind<ISimulationParametersView>().To<SimulationParametersView>();
            kernel.Bind<IParametersService>().To<ParametersService>();
            kernel.Bind<IRepository<int>>().To<SimParametersRepository>();
            kernel.Bind<ISimulationView>().To<SimulationView>();
            kernel.Bind<ISimulationService>().To<SimulationService>();
            kernel.Bind<ICreatePeopleView>().To<CreatePeopleView>();
            kernel.Bind<IPeopleService>().To<PeopleService>();
            kernel.Bind<IRepository<Human>>().To<PeopleRepository>();
            kernel.Bind<IRepository<Elevator>>().To<ElevatorRepository>();
            kernel.Bind<IRepository<byte>>().To<OuterBuffer>();
            kernel.Bind<IRepository<bool>>().To<PushedButtonsRepository>();
            kernel.Bind<ISetRuleView>().To<SetRuleView>();
            kernel.Bind<IRuleService>().To<RuleService>();
            kernel.Bind<IRepository<FixedGenRule>>().To<FixedGenRuleRepository>();
            kernel.Bind<IRepository<RandomGenRule>>().To<RandomGenRuleRepository>();
            kernel.Bind<IDeleteRuleView>().To<DeleteRuleView>();
            kernel.Bind<IDeleteRuleService>().To<DeleteRuleService>();
            kernel.Bind<IChangeSpeedView>().To<ChangeSpeedView>();
            kernel.Bind<IChangeSpeedService>().To<ChangeSpeedService>();
            kernel.Bind<IRepository<SpeedTiming>>().To<SpeedRepository>();
            kernel.Bind<IStatsView>().To<StatsView>();
            kernel.Bind<IStatsService>().To<StatsService>();
            kernel.Bind<IRepository<Thread>>().To<PoolOfThreads>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            kernel.Get<SimParametersPresenter>().Run();
            Application.Run(kernel.Get<ApplicationContext>());
        }

        internal class WinFormTimer : System.Windows.Forms.Timer, ITimer { }
    }
}
