using System;
using Microsoft.Extensions.DependencyInjection;
using MultiStore.Data.Entities;
using MultiStore.Data.Repositories;
using MultiStore.Interfaces.Repositories;
using MultiStore.Interfaces.Services;
using MultiStore.Services;

namespace MultiStore.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IArticleService, ArticleService>();
            services.AddSingleton<IArticleRequestService, ArticleRequestService>();
            services.AddSingleton<IBrandService, BrandService>();
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IPurchaseOrderService, PurchaseOrderService>();
            services.AddSingleton<ISupplierService, SupplierService>();
        }
    }
}
