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

          
            //ע��SQLʵ����
            services.AddDbContext<Dbcontext>(opt => opt.UseSqlServer("Server=localhost\\ADMIN;Initial Catalog=KestrelSystemData; uid=sa;pwd=123456;MultipleActiveResultSets=True"));

            services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<Dbcontext>()
             .AddDefaultTokenProviders();


            var Issurer = "JWTBearer.Auth";//������
            var Audience = "api.auth";       //������
            var secretCredentials = "q2xiARx$4x3TKqBJ";   //��Կ

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "webapidemo", Version = "v1" });
            });

            // ��ӿ������ݷ��ʷ���
            //���cors ���� ���ÿ�����            
 
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
                    //�Ƿ���֤������
                    ValidateIssuer = true,
                    ValidIssuer = Issurer,//������
                                         
                    ValidateAudience = true, //�Ƿ���֤������
                    ValidAudience = Audience,//������
                                             //�Ƿ���֤��Կ
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretCredentials)),

                    ValidateLifetime = true, //��֤��������
                    RequireExpirationTime = true, //����ʱ��
                };
            });
            //   ��� DI ����
            //�û�

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

            //��Ʒ
            services.AddScoped<IEntityRepository<ProductInfo>, EntityRepository<ProductInfo>>();
            services.AddScoped<IWebAPIModelService<ProductInfo, ProductInfoVM>, WebAPIModelService<ProductInfo, ProductInfoVM>>();

            services.AddScoped<IEntityRepository<PCategory>, EntityRepository<PCategory>>();
            services.AddScoped<IWebAPIModelService<PCategory, PCategoryVM>, WebAPIModelService<PCategory, PCategoryVM>>();

            services.AddScoped<IEntityRepository<PRecord>, EntityRepository<PRecord>>();
            services.AddScoped<IWebAPIModelService<PRecord, PRecordVM>, WebAPIModelService<PRecord, PRecordVM>>();

            //ԭ��
            services.AddScoped<IEntityRepository<MaterialsInfo>, EntityRepository<MaterialsInfo>>();
            services.AddScoped<IWebAPIModelService<MaterialsInfo, MaterilsInfoVM>, WebAPIModelService<MaterialsInfo, MaterilsInfoVM>>();

            services.AddScoped<IEntityRepository<MCategory>, EntityRepository<MCategory>>();
            services.AddScoped<IWebAPIModelService<MCategory, MCategoryVM>, WebAPIModelService<MCategory, MCategoryVM>>();

            services.AddScoped<IEntityRepository<RMRecord>, EntityRepository<RMRecord>>();
            services.AddScoped<IWebAPIModelService<RMRecord, RMRecordVM>, WebAPIModelService<RMRecord, RMRecordVM>>();


            //����
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
            // ��������������
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("AnyOrigin");//֧�ֿ��������ض���Դ����������
 
            app.UseHttpsRedirection();

            app.UseDefaultFiles();
 
            //1.�ȿ�����֤
            app.UseAuthentication();
            //2.�ٿ�����Ȩ
            app.UseAuthorization();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();//֧�ֿ���;
            });
        }
    }
}
