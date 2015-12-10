
using SuiteSolution.Service.EF;
using SuiteSolution.Service.Entities;
using SuiteSolution.Service.Interface;
using System;
using System.Collections.Generic;

namespace SuiteSolution.Service.Implement
{
    public class ApplicationDataService : IApplicationDataService
    {
        public void Dispose()
        {
        }

        public List<ApplicationMenu> GetMenuItems(bool isAuthenicated, out TransactionalInformation transaction)
        {
            transaction = new TransactionalInformation();
            List<ApplicationMenu> list = new List<ApplicationMenu>();
            try
            {
            
                
                list.Add(CreateMenuItem("Home", "#Main/Home", "Main", false, 1));
                list.Add(CreateMenuItem("Register", "#Accounts/Register", "Main", false, 3));
                list.Add(CreateMenuItem("Login", "#Accounts/Login", "Main", false, 4));
                list.Add(CreateMenuItem("Customer", "#Customer/", "Main", false, 5));
                transaction.ReturnStatus = true;
            }
            catch (Exception ex)
            {
                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
            }
            finally
            {
               
            }

            return list;


        }

        /// <summary>
        /// Create Menu Item
        /// </summary>
        /// <param name="description"></param>
        /// <param name="route"></param>
        /// <param name="module"></param>
        /// <param name="requiresAuthenication"></param>
        /// <param name="menuOrder"></param>
        /// <returns></returns>
        private ApplicationMenu CreateMenuItem(string description, string route, string module, Boolean requiresAuthenication, int menuOrder)
        {
            ApplicationMenu menuItem = new ApplicationMenu();
            menuItem.MenuId = Guid.NewGuid();
            menuItem.Route = route;
            menuItem.Description = description;
            menuItem.RequiresAuthenication = requiresAuthenication;
            menuItem.MenuOrder = menuOrder;
            menuItem.Module = module;
            return menuItem;
        }
    }
}
