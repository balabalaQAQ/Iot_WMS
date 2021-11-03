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
                  <b-form-input id="elementsAppendButton" type="text"></b-form-input>
                  <b-input-group-append>
                    <b-button variant="primary" size="sm">查询</b-button>
                  </b-input-group-append>&nbsp;
                  <b-button variant="primary" squared size="sm" @click="createData()">
                    <i class="fa fa-lightbulb-o"></i>&nbsp;新建数据
                  </b-button>
                </b-input-group>
              </div>
            </div>
            <!-- 使用 bootstrapVue table 控件处理列表 -->
            <b-table
              :hover="hover"
              :striped="striped"
              :bordered="bordered"
              :small="small"
              :fixed="fixed"
              responsive="sm"
              :items="items.UsersData"
              :fields="fields"
              :current-page="currentPage"
              :per-page="perPage"
            >
              <!-- 定制列表单元显示 -->
            
              <!-- 定制列表单元显示 -->
              
              <!-- 数据操作 -->
              <template slot="operation" slot-scope="data">
                <b-button variant="primary" size="sm" @click="editData(data.id)">编辑</b-button>&nbsp;
                <b-button variant="primary" size="sm" @click="detailData(data.id)">明细</b-button>&nbsp;
                <b-button variant="danger" size="sm" @click="deleteData(data.id)">删除</b-button>
              </template>
            </b-table>

            <!-- 分页导航 -->
            <nav>
              <b-pagination
                size="sm"
                :total-rows="getRowCount(items)"
                :per-page="perPage"
                v-model="currentPage"
                prev-text="前一页"
                next-text="下一页"
                hide-goto-end-buttons
                align="right"
              />
            </nav>
          </b-card>
        </transition>
      </b-col>
    </b-row>
  </div>
</template>

<script>
// 导入数据源
import demoData from "./DemoData";

export default {
  name: "DataList",
  // 表格规格定义参数及缺省值设置
  props: {
    // 列表的表格标题
    caption: {
      type: String,
      default: "会员信息"
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

  data: function() {
    return {
      // 绑定数据
      //  items: demoData.filter((test) => test.orderNumber < 1200),  // 提取 id < 42 的全部数据
      items: [],

      fields: [
        { key: "orderNumber", label: "序号" },
        { key: "name", label: "姓名" },
        { key: "AdmissionTime", label: "注册日期" },
        { key: "lastTime", label: "最后一次使用日期" },
        { key: "integral", label: "积分" },
        { key: "roleName", label: "会员等级" },
        { key: "StatusName", label: "状态" },
        { key: "operation", label: "操作" }
      ],
      currentPage: 1, // 当前页
      perPage: 5, // 每页数据数量
      totalRows: 0 // 总的行数
    };
  },

  computed: {},

  methods: {
    // 处理状态显示的样式
    getBadge(status) {
      return status === "Active"
        ? "success"
        : status === "Inactive"
        ? "secondary"
        : status === "Pending"
        ? "warning"
        : status === "Banned"
        ? "danger"
        : "primary";
    },
    // 提取总行数
    getRowCount(items) {
             console.log(110);
      return items.UsersData.length;
    },
    // 用户详细数据链接
    userLink(id) {
      return `users/${id.toString()}`;
    },
    // 单击行事件
    rowClicked(item) {
      const userLink = this.userLink(item.id);
      this.$router.push({ path: userLink });
    },
    // 新建数据
    createData() {
      this.$router.push({ name: "DataCreate" });
    },
    // 编辑数据
    editData(itemId) {
      const editLink = `dataEdit/${itemId.toString()}`; // 使用变量引号 ` 以$前缀获取变量进行处理
      this.$router.push({ path: editLink });
    },
    // 明细数据
    detailData(itemId) {
      this.$router.push({ name: "DataDetail", params: { id: itemId } });
    },
    // 伤处数据
    deleteData(itemId) {
      this.$router.push({ name: "DataDelete", params: { id: itemId } });
    }
  },

  created() {
    this.items = demoData;
    var d= demoData.UsersData;
    var status = demoData.StatusData;
    var role = demoData.RoleData;

    d.forEach(x => {
      console.log(x);
      var sta = status.find(function(all) {
       
        return x.Statusid == all.Statusid;
      });
     
      x.StatusName = sta.StatusName;
      
        var ro = role.find(function(rol) {
       
        return x.roleid == rol.roleid;
      });
   
      x.roleName = ro.roleName;
     
    });

  }
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
