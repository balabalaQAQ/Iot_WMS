import Oidc from 'oidc-client'

var oidcSettings =
{
    authority: "http://localhost:5000",
    client_id: "demo_001",
    redirect_uri: "http://localhost:1337/#/IntegralMall/Token#",
    response_type: "id_token token",
    scope: "api1 openid",
    post_logout_redirect_uri: "https://localhost:5001/ ",



    
  //  silent_reirect_uri:"http://localhost:1337/#/IntegralMall/Token",//Token自动刷新页面
  //  accessTokenExpiringNotificationTime:4,   //过期前4秒请求刷新Token
  //automaticSilentRenew:true,//自动刷新Token
  //   filterProtocolClaims:true
}

const mgr = new Oidc.UserManager(oidcSettings)




export default mgr
