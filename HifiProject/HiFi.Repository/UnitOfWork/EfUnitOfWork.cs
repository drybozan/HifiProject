using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiFi.EF.Models;

namespace HiFi.Repository
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly HiFiDBEntities _dbContext;

        public EFUnitOfWork(HiFiDBEntities dbContext)
        {
            Database.SetInitializer<HiFiDBEntities>(null);

            if (dbContext == null)
                throw new ArgumentNullException("dbContext can not be null.");

            _dbContext = dbContext;

            // Buradan istediğiniz gibi EntityFramework'ü konfigure edebilirsiniz.
            //_dbContext.Configuration.LazyLoadingEnabled = false;
            //_dbContext.Configuration.ValidateOnSaveEnabled = false;
            //_dbContext.Configuration.ProxyCreationEnabled = false;
        }

        //WORKING WITH TABLES
        private EFRepository<memberTBL> _memberRepository;
        private EFRepository<logTBL> _logRepository;
        private EFRepository<setupTBL> _setupRepository;
        private EFRepository<setupPictureTBL> _setupPictureRepository;
        private EFRepository<setupComponentTBL> _setupComponentRepository;
        private EFRepository<compPictureTBL> _compPictureRepository;
        private EFRepository<systemCategoryTBL> _systemCategoryRepository;
        private EFRepository<applicationTBL> _applicationRepository;


        public EFRepository<memberTBL> MembersTemplate => _memberRepository ?? (_memberRepository = new EFRepository<memberTBL>(_dbContext));
        public EFRepository<logTBL> LogsTemplate => _logRepository ?? (_logRepository = new EFRepository<logTBL>(_dbContext));
        public EFRepository<setupTBL> SetupsTemplate => _setupRepository ?? (_setupRepository = new EFRepository<setupTBL>(_dbContext));
        public EFRepository<setupPictureTBL> SetupPicturesTemplate => _setupPictureRepository ?? (_setupPictureRepository = new EFRepository<setupPictureTBL>(_dbContext));
        public EFRepository<setupComponentTBL> SetupComponentsTemplate => _setupComponentRepository ?? (_setupComponentRepository = new EFRepository<setupComponentTBL>(_dbContext));
        public EFRepository<compPictureTBL> CompPicturesTemplate => _compPictureRepository ?? (_compPictureRepository = new EFRepository<compPictureTBL>(_dbContext));
        public EFRepository<systemCategoryTBL> SystemCategoriesTemplate => _systemCategoryRepository ?? (_systemCategoryRepository = new EFRepository<systemCategoryTBL>(_dbContext));
        public EFRepository<applicationTBL> ApplicationTemplate => _applicationRepository ?? (_applicationRepository = new EFRepository<applicationTBL>(_dbContext));

        #region IUnitOfWork Members
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EFRepository<T>(_dbContext);
        }

        public int SaveChanges()
        {
            try
            {
                // Transaction işlemleri burada ele alınabilir veya Identity Map kurumsal tasarım kalıbı kullanılarak
                // sadece değişen alanları güncellemeyide sağlayabiliriz.
                return _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
        #endregion

        #region IDisposable Members
        // Burada IUnitOfWork arayüzüne implemente ettiğimiz IDisposable arayüzünün Dispose Patternini implemente ediyoruz.
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
