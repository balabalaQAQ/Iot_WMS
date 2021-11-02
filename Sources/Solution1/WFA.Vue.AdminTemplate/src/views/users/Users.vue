<template>
  <b-row>
    <b-col cols="12" xl="12">
      <transition name="slide">
      <b-card>
        <div slot="header" v-html="caption"></div>
        <b-table :hover="hover" :striped="striped" :bordered="bordered" :small="small" :fixed="fixed" responsive="sm" :items="items" :fields="fields" :current-page="currentPage" :per-page="perPage" @row-clicked="rowClicked">
          <template slot="id" slot-scope="data">
            <strong>{{data.item.id}}</strong>
          </template>
          <template slot="name" slot-scope="data">
            <strong>{{data.item.name}}</strong>
          </template>
          <template slot="status" slot-scope="data">
            <b-badge :variant="getBadge(data.item.status)">{{data.item.status}}</b-badge>
          </template>
        </b-table>
        <nav>
          <b-pagination size="sm" :total-rows="getRowCount(items)" :per-page="perPage" v-model="currentPage" prev-text="Prev" next-text="Next" hide-goto-end-buttons/>
        </nav>
      </b-card>
      </transition>
    </b-col>
  </b-row>
</template>

<script>
  // 获取用户数据
  import usersData from './UsersData'
  export default {
    name: 'Users',
    props: {
      caption: {
        type: String,
        default: '用户信息清单'
      },
      hover: {
        type: Boolean,
        default: true
      },
      striped: {
        type: Boolean,
        default: true
      },
      bordered: {
        type: Boolean,
        default: false
      },
      small: {
        type: Boolean,
        default: false
      },
      fixed: {
        type: Boolean,
        default: false
      }
    },
    data: () => {
      return {
        items: usersData.filter((user) => user.id < 42),
        fields: [
          {key: 'id', label:"序号"},
          {key: 'name' ,label:"姓名"},
          {key: 'registered',label:"注册日期"},
          {key: 'role',label:"系统角色"},
          {key: 'status',label:"状态"}
        ],
        currentPage: 1,
        perPage: 5,
        totalRows: 0
      }
    },
    computed: {
    },
    methods: {
      // 处理状态显示的样式
      getBadge (status) {
        return status === 'Active' ? 'success'
          : status === 'Inactive' ? 'secondary'
            : status === 'Pending' ? 'warning'
              : status === 'Banned' ? 'danger' : 'primary'
      },
      // 提取行数
      getRowCount (items) {
        return items.length
      },
      // 用户详细数据链接
      userLink (id) {
        return `users/${id.toString()}`
      },
      // 单击行事件
      rowClicked (item) {
        const userLink = this.userLink(item.id)
        this.$router.push({path: userLink})
      }

    }
  }
</script>

<style scoped>
.card-body >>> table > tbody > tr > td {
  cursor: pointer;
}
</style>
