using EntityModel.Order;
using EntityModel.Product;
using EntityModel.RawMaterials;
using EntityModel.Users;
using Kestrel.DataAccess;
using Kestrel.IWebAPIModelService;
using Kestrel.ORM;
using Kestrel.WebAPIModelService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Orders;
using ViewModels.Product;
using ViewModels.RawMaterials;
using ViewModels.User;

namespace webapidemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddMvcCore().AddAuthorization();

          
            //注意SQL实例名
            services.AddDbContext<Dbcontext>(opt => opt.UseSqlServer("Server=localhost\\ADMIN;Initial Catalog=KestrelSystemData; uid=sa;pwd=123456;MultipleActiveResultSets=True"));

            services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<Dbcontext>()
             .AddDefaultTokenProviders();


            var Issurer = "JWTBearer.Auth";//发行人
            var Audience = "api.auth";       //受众人
            var secretCredentials = "q2xiARx$4x3TKqBJ";   //密钥

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "webapidemo", Version = "v1" });
            });

            // 添加跨域数据访问服务
            //添加cors 服务 配置跨域处理            
 
            services.AddCors(options =>
            {
                options.AddPolicy("AnyOrigin", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    //是否验证发行人
                    ValidateIssuer = true,
                    ValidIssuer = Issurer,//发行人
                                         
                    ValidateAudience = true, //是否验证受众人
                    ValidAudience = Audience,//受众人
                                             //是否验证密钥
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretCredentials)),

                    ValidateLifetime = true, //验证生命周期
                    RequireExpirationTime = true, //过期时间
                };
            });
            //   添加 DI 配置
            //用户

            //services.AddScoped<IWebAPIModelService<IUser, UserVM>, WebAPIModelService<IUser, UserVM>>();
            services.AddScoped<IEntityRepository<IUser>, EntityRepository<IUser>>();
            services.AddScoped<IWebAPIModelService<IUser, UserVM>, WebAPIModelService<IUser, UserVM>>();


            services.AddScoped<IEntityRepository<IRole>, EntityRepository<IRole>>();
            services.AddScoped<IWebAPIModelService<IRole, RoleVM>, WebAPIModelService<IRole, RoleVM>>();
            //  services.AddScoped<IWebAPIModelService<Role, RoleVM>, WebAPIModelService<Role, RoleVM>>();

            services.AddScoped<IEntityRepository<User>, EntityRepository<User>>();
          //  services.AddScoped<IWebAPIModelService<User, UserVM>, WebAPIModelService<User, UserVM>>();


            services.AddScoped<IEntityRepository<Role>, EntityRepository<Role>>();
          //  services.AddScoped<IWebAPIModelService<Role, RoleVM>, WebAPIModelService<Role, RoleVM>>();

            //产品
            services.AddScoped<IEntityRepository<ProductInfo>, EntityRepository<ProductInfo>>();
            services.AddScoped<IWebAPIModelService<ProductInfo, ProductInfoVM>, WebAPIModelService<ProductInfo, ProductInfoVM>>();

            services.AddScoped<IEntityRepository<PCategory>, EntityRepository<PCategory>>();
            services.AddScoped<IWebAPIModelService<PCategory, PCategoryVM>, WebAPIModelService<PCategory, PCategoryVM>>();

            services.AddScoped<IEntityRepository<PRecord>, EntityRepository<PRecord>>();
            services.AddScoped<IWebAPIModelService<PRecord, PRecordVM>, WebAPIModelService<PRecord, PRecordVM>>();

            //原料
            services.AddScoped<IEntityRepository<MaterialsInfo>, EntityRepository<MaterialsInfo>>();
            services.AddScoped<IWebAPIModelService<MaterialsInfo, MaterilsInfoVM>, WebAPIModelService<MaterialsInfo, MaterilsInfoVM>>();

            services.AddScoped<IEntityRepository<MCategory>, EntityRepository<MCategory>>();
            services.AddScoped<IWebAPIModelService<MCategory, MCategoryVM>, WebAPIModelService<MCategory, MCategoryVM>>();

            services.AddScoped<IEntityRepository<RMRecord>, EntityRepository<RMRecord>>();
            services.AddScoped<IWebAPIModelService<RMRecord, RMRecordVM>, WebAPIModelService<RMRecord, RMRecordVM>>();


            //订单
            services.AddScoped<IEntityRepository<Order>, EntityRepository<Order>>();
            services.AddScoped<IWebAPIModelService<Order, OrderVM>, WebAPIModelService<Order, OrderVM>>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
 
            }
            // 允许跨域访问请求
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("AnyOrigin");//支持跨域：允许特定来源的主机访问
 
            app.UseHttpsRedirection();

            app.UseDefaultFiles();
 
            //1.先开启认证
            app.UseAuthentication();
            //2.再开启授权
            app.UseAuthorization();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();//支持跨域;
            });
        }
    }
}
