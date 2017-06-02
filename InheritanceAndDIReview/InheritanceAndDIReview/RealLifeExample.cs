using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndDIReview
{


    public class PortfolioProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }

    public interface IDataStorage
    {
        List<PortfolioProject> GetListOfPortfolio();
    }

    public class SqlDataStorage : IDataStorage
    {
        public List<PortfolioProject> GetListOfPortfolio()
        {
            return new List<PortfolioProject>(); // Form database db.PortfolioProjects.toList()'
        }
    }


    public class PortfolioService
    {
        public IDataStorage DataStorage { get; set; }

        public PortfolioService(IDataStorage storage)
        {
            this.DataStorage = storage;
        }

        public List<PortfolioProject> GetAllPortfolioProjects()
        {
            return DataStorage.GetListOfPortfolio();
        }
    }


    // controller 

    public ActionResult Index()
    {
        var db = new SqlDataStorage();
        var portfolio = new PortfolioService(db).GetAllPortfolioProjects();
        return View(portfolio);
    }



}
