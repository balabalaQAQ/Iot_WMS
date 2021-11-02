<template>
  <div class="animated fadeIn">
    <b-row>
      <b-col sm="12" md="12">
        <transition name="fade">
          <b-card>
            <div slot="header">
              <span style="font-size:20px">{{caption}}</span>
            </div>
            <span>姓名：</span>
            <b-form-input
              id="input-1"
              v-model="user.name"
              type="text"
              required
              placeholder="Enter name"
            ></b-form-input>

            <span>积分：</span>

            <b-form-input v-model="user.score" type="text" required placeholder="Enter score"></b-form-input>

            <span>注册时间：</span>
            <b-form-input type="date" v-model="user.date"></b-form-input>

            <button @click="Create()">创建</button>
          </b-card>
        </transition>
      </b-col>
    </b-row>
  </div>
</template>
<script>
import data from "./DemoData";
export default {
  name: "DataCreate",
  props: {
    caption: {
      type: String,
      default: "新建会员信息"
    }
  },
  data() {
    return {
      user: {
        id: "",
        name: "",
        date: "",
        score: 0,
        enddate: "",
        orderNumber: ""
      }
    };
  },
  methods: {
    Create: function() {
      this.user.id = "91E52E80-E4EC-429E-BA46-27494195CB26";
      this.user.orderNumber=26;
      
      data.push(this.user);

      this.$router.push({name:'DataList'});
    }
  }
};
</script>

<style scoped>
</style>
