<template>
   <div class="animated fadeIn">
    <b-row>
      <b-col sm="12" md="12">
        <transition name="fade">
          <b-card>
            <!-- 数据列表表头 -->
            <div slot="header">
              <span style="font-size:20px">{{caption}}</span>
              <div class="card-header-actions">
                <b-input-group>
                  <b-form-input id="searchText" type="text" placeholder="按产品名称、类别"></b-form-input>
                  <b-input-group-append>
                    <b-button variant="primary" size="sm"  @click="searchData(mumitems)">查询</b-button>
                  </b-input-group-append>&nbsp;
                  <b-button method="POST" variant="primary" squared size="sm" @click="createData()">
                    <i class="fa fa-lightbulb-o"></i>&nbsp;新建数据
                  </b-button>
                </b-input-group>
              </div>
            </div>
            <!-- 使用 bootstrapVue table 控件处理列表 -->
            <b-table :hover="hover"
                     :striped="striped"
                     :bordered="bordered"
                     :small="small" 
                     :fixed="fixed"
                     responsive="sm"
                     :items="getmumitems"
                     :fields="fields"
                     :current-page="currentPage"
                     :per-page="perPage">
              <!-- 数据操作 -->
              <template slot="operation" slot-scope="data">
                <b-button variant="primary" size="sm" @click="editData(data.item.id)">编辑</b-button>&nbsp;&nbsp;&nbsp;
                <b-button variant="primary" size="sm" @click="insPRecordData(data.item,data.item.id,data.item.name)">(出)入库</b-button>&nbsp;&nbsp;&nbsp;
                <b-button variant="danger" size="sm" @click="deleteData(data.item.id)">删除</b-button>
              </template>
            </b-table>

            <!-- 分页导航 -->

             <nav>
              <b-pagination
                size="sm"
                :total-rows="getRowCount(mumitems)"
                :per-page="perPage"
                v-model="currentPage"
                prev-text="前一页"
                next-text="下一页"
                hide-goto-end-buttons
                align="right"
              
              />
            </nav>
              <!--
            <nav>
              <b-pagination size="sm"
                            :per-page="perPage"
                            v-model="currentPage"
                            prev-text="前一页"
                            next-text="下一页"
                            hide-goto-end-buttons
                            align="right"
                            @input="gotoPage(currentPage)" />
            </nav>
            -->
          </b-card>
        </transition>
      </b-col>
    </b-row>
  </div>
</template>
<script src="./site.js" asp-append-version="true"></script>

<script>

function displayData(mumitems){//对显示的数据进行预处理
    for( var i=0;i< mumitems.length;i++){
      var daynow = new Date();
      daynow.setTime(daynow.getTime());
      var dateBegin = new Date(mumitems[i].setTime); 
      if( Math.floor(daynow.getTime()-dateBegin.getTime()) / (24 * 3600 * 1000)>=30){//间隔30天以上则不为新产品
        //mumitems[i].isNew="否";
       
      }
      else{
       // mumitems[i].isNew="是";
      }
      //避免一些数据太长的影响
      if(mumitems[i].description.length>=10)
          mumitems[i].description=mumitems[i].description.substr(0,20)+"..."
      if(mumitems[i].name.length>=10)
          mumitems[i].name=mumitems[i].name.substr(0,10)+"..."
      
    }
    return mumitems;
  }
  // const uri = '/WeatherForecast';   // Web API 的访问服务地址
const uri ='https://localhost:5001/api/ProductInfo/';
var flag=0; //查询状态
//import { shuffleArray } from "@/shared/utils";
 // import Oidc from "oidc-client" ;

  export default {
    name: "ProductIndex",
    props: {
      // 列表的表格标题
      caption: {
        type: String,
        default: "产品列表"
      },
      hover: {
        type: Boolean,
        default: true
      },
      striped: {
        type: Boolean,
        default: false
      },
      bordered: {
        type: Boolean,
        default: true
      },
      small: {
        type: Boolean,
        default: true
      },
      fixed: {
        type: Boolean,
        default: false
      }
    },

    data: function () {
       
      return {
        // 绑定数据
        //  items: demoData.filter((test) => test.orderNumber < 1200),  // 提取 id < 42 的全部数据

        mumitems: [],//初始数据集，用于显示
        saveitems:[],//用于保存原数据集
        searchitems:[],//查询后的数据集
        fields: [
          { key: "orderNumber", label: "序号" },
          { key: "productID", label: "产品编号" },
          { key: "name", label: "产品名" },
          { key: "pCategory.name", label: "类别" },
          { key: "inventory", label: "库存量" },
          { key: "price", label: "单价" },
          //{ key: "isNew", label: "是否为新" },
          { key: "description", label: "产品描述" },
          { key: "operation", label: "操作" }
        ],
     
        currentPage: 1, // 当前页
        perPage: 10, // 每页数据数量
        totalRows: 0 // 总的行数
      };
    },
 

    computed: {
      getmumitems: function () {
       var item=this
       this.$axios.get(uri).then(function(res){
              if(flag==0)
                item.mumitems=res.data;
              else//进入查询
                item.mumitems=[...item.saveitems];//为数组的数据类型进行转化
       })
       return (item.mumitems)
      },
    },
    methods: {    
      getRowCount(mumitems) {
        return mumitems.length;
      },
      searchData(mumitems){
        flag=1;
        var item=this;
        item.mumitems.splice(0,item.mumitems.length);
        item.saveitems.splice(0,item.saveitems.length);
        const searchTextbox = document.getElementById('searchText').value.trim();//获取输入文本框的内容
        this.$axios.get(uri).then(function(res){
        if(searchTextbox==''||searchTextbox==undefined||searchTextbox==null){//判读是否为空
              item.mumitems=item.saveitems = displayData(res.data)
              flag=0;
         }
        else{
           var count=0;
           for(var i=0;i<res.data.length;i++){        
           if (res.data[i].name.indexOf(searchTextbox) != -1||res.data[i].pCategory.name.indexOf(searchTextbox) != -1  ) { //检索条件
            item.searchitems[count]=(res.data[i]);//将检索的数据添加到查询集
            count++;
           }
             item.saveitems=item.searchitems; //为每一个数据集都赋值
           }
         }})
      },
    
      createData() {
        this.$router.push({
           name: "ProductIns",
           params: {pcategory:this.mumitems[0].pCategoryList}
         });   
      },
      editData(id) {
        this.$router.push({
          name: "ProductEdit",
          params: { id: id,pcategory:this.mumitems[0].pCategoryList}
        })
      },
      deleteData(id) {
        this.$axios.delete(uri+id)
        },
      insPRecordData(item,id,name)  {
         this.$router.push({
          name: "PRecordIns",
          params: { item:item,id: id,name:name}
        })
     }
    },
    created() {
       var item=this
       flag=0;
       this.$axios.get(uri).then(function(res){
       item.mumitems = displayData(res.data)
       })
       
    },
  };
 
</script>

<style scoped>
  .fade-enter-active {
    transition: all 0.3s ease;
  }

  .fade-leave-active {
    transition: all 0.8s cubic-bezier(1, 0.5, 0.8, 1);
  }

  .fade-enter,
  .fade-leave-to {
    transform: translateX(10px);
    opacity: 0;
  }
</style>
