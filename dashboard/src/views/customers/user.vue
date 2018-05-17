<template>
  <div>
    <Card>
      <p slot="title">用户信息</p>
      <Row :gutter="8" slot="extra">
        <i-col span="6">
          <Input placeholder="昵称" v-model="params.name" />
        </i-col>
        <i-col span="6">
          <Input placeholder="家族" v-model="params.family"/>
        </i-col>
        <i-col span="6">
          <Select style="width:140px" v-model="params.level" placeholder="家族级别">
              <Option value="null">全部</Option>
              <Option value="1">一级</Option>
              <Option value="2">二级</Option>
              <Option value="3">三级</Option>
            </Select>
        </i-col>
        <i-col offset="1" span="3">
          <i-button @click="getpage" type="primary">查询</i-button>
        </i-col>
        <!-- <i-col span="3">
          <i-button @click="create" type="primary">添加</i-button>
        </i-col> -->
      </Row>
      <Table :columns="columns" border :data="customers"></Table>
      <Page :total="totalCount" class="margin-top-10" @on-change="pageChange" @on-page-size-change="pagesizeChange" :page-size="pageSize"
        :current="currentPage"></Page>
    </Card>
  </div>
</template>
<script>
export default {
  methods: {
    pageChange(page) {
      this.$store.commit("customer/setCurrentPage", page);
      this.getpage();
    },
    pagesizeChange(pagesize) {
      this.$store.commit("customer/setPageSize", pagesize);
      this.getpage();
    },
    async getpage() {
      await this.$store.dispatch({
        type: "customer/getAll",
        data: this.params
      });
    }
  },
  data() {
    return {
      params: {
        name: "",
        family: "",
        level: null
      },
      columns: [
        {
          type: "selection",
          width: 60,
          align: "center"
        },
        {
          title: "头像",
          key: "avatarUrl"
        },
        {
          title: "昵称",
          key: "name"
        },
          {
          title: "猿人币余额",
          key: "balance"
        },
        {
          title: "所属家族",
          key: "family"
        },
        {
          title: "族内级别",
          key: "familyCode"
        },
        {
          title: "注册时间",
          key: "creationTime",
          render: (h, params) => {
            return this.formatter(params.row.creationTime);
          }
        }
      ]
    };
  },
  computed: {
    customers() {
      return this.$store.state.customer.customers;
    },
   
    totalCount() {
      return this.$store.state.customer.totalCount;
    },
    currentPage() {
      return this.$store.state.customer.currentPage;
    },
    pageSize() {
      return this.$store.state.customer.pageSize;
    }
  },
  async created() {
    this.getpage();
    await this.$store.dispatch({
      type: "customer/getAll",
      data:this.params
    });
  }
};
</script>