import axios from 'axios'
 

axios.defaults.baseURL = '/api'
//请求时的拦截
axios.interceptors.request.use(function(config){
     config.headers['authorization']='Bearer ';
     return config;
},
    function(err){
        return Promise.reject(err)
    })


    axios.interceptors.response.use(function(res)
    {
        var httpcode=res.status;
        switch(httpcode)
        {
            case 200:break
        }
        return res;
    },
        function(err)
        {
            return Promise.reject(err)

        }
    )
export default axios