using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using biz2biz.Model;
using biz2biz.Repository;
using biz2biz.Repository.context;
using biz2biz.Repository.Interfaces;
using biz2biz.ViewModel;
using biz2biz.ViewModel.AccountViewModels;
using biz2biz.ViewModel.AnnonceViewModels;

namespace biz2biz.Service
{
    /// <summary>
    /// This service class have connection to item repository
    /// This will be responsible for creating items
    /// Images for the items is created in ImageService
    /// </summary>
    public class AnnonceService
    {
        private IAnnonceRepository<Annonce> _annonceRepository;
        private IManufacturerRepository<Manufacturer> _manufacturerRepository;
        private IAccountRepository<Account> _accountRepository; 
        public AnnonceService()
        {
            Context con = new Context();
            _annonceRepository = new AnnonceRepository(con);
            _manufacturerRepository = new ManufacturerRepository(con);
            _accountRepository = new AccountRepository(con);
        }


        public AnnonceViewModel CreateNewAnnonce(int accountid,AnnonceCreateViewModel model)
        {

            Annonce annonce = Mapper.Map<AnnonceCreateViewModel, Annonce>(model);
            Account acc = _accountRepository.GetAccount(accountid);
            annonce.CreatedBy = acc;
            annonce.Owner = acc.Company;
            annonce.Product = _manufacturerRepository.GetProductByID(model.ProductID);
            annonce.Created = DateTime.Now;
            annonce.Comments = new List<Comment>();
            annonce.ExpirationDate = annonce.Created.AddDays(27);
            annonce.Manufacturer = _manufacturerRepository.GetManufacturer(model.ManufacturerID);
            annonce = _annonceRepository.AddItem(annonce);
            AnnonceViewModel viewmodelmodel = Mapper.Map<Annonce, AnnonceViewModel>(annonce);
            return viewmodelmodel;
        }

        public ProductViewModel GetProductByID(int id)
        {
            Product product = _manufacturerRepository.GetProductByID(id);
            return Mapper.Map<Product, ProductViewModel>(product);
        }

        public List<AnnonceTypeViewModel> GetAnnonceTypes(string searchstring)
        {
            List<AnnonceType> products = !string.IsNullOrWhiteSpace(searchstring)? _manufacturerRepository.GetAllAnnonceTypeContainingString(searchstring): new List<AnnonceType>();
            List<AnnonceTypeViewModel> allannoncetypes = new List<AnnonceTypeViewModel>();
            allannoncetypes.AddRange(products.Select(Mapper.Map<AnnonceType, AnnonceTypeViewModel>));
            return allannoncetypes;
        }
    }
}
