<template>
  <div>
    <Card>
      <p slot="title">工作/任务信息</p>
      <Row :gutter="8" slot="extra">
        <i-col span="6">
          <Input placeholder="任务名称" v-model="params.name">
          </Input>
        </i-col>
        <i-col span="6">
          <Input placeholder="发布人昵称" v-model="params.num">
          </Input>
        </i-col>
        <i-col span="6">
          <Input placeholder="承接人昵称" v-model="params.num">
          </Input>
        </i-col>
        <i-col offset="1" span="3">
          <i-button @click="getpage" type="primary">查询</i-button>
        </i-col>
        <!-- <i-col span="3">
          <i-button @click="create" type="primary">添加</i-button>
        </i-col> -->
      </Row>
      <Table :columns="columns" border :data="devices"></Table>
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
        num: "",
        cate: ""
      },
      columns: [
        {
          type: "selection",
          width: 60,
          align: "center"
        },
        {
          title: "任务名称",
          key: "deviceName"
        },
        {
          title: "发布人昵称",
          key: "deviceNum"
        },
          {
          title: "承接任务人昵称",
          key: "controlNum"
        },
        {
          title: "项目金额",
          key: "deviceType"
        },
        {
          title: "一级奖金",
          key: "pointName"
        },
          {
          title: "二级奖金",
          key: "pointName"
        },
          {
          title: "三级奖金",
          key: "pointName"
        },
          {
          title: "承接时间",
          key: "pointName"
        },
          {
          title: "完成时间",
          key: "pointName"
        },
        {
          title: "创建时间",
          key: "creationTime",
          render: (h, params) => {
            return this.formatter(params.row.creationTime);
          }
        }
      ]
    };
  },
  computed: {
    devices() {
      return this.$store.state.device.devices;
    },
    points() {
      return this.$store.state.device.points;
    },
    totalCount() {
      return this.$store.state.device.totalCount;
    },
    currentPage() {
      return this.$store.state.device.currentPage;
    },
    pageSize() {
      return this.$store.state.point.pageSize;
    }
  },
  async created() {
    this.getpage();
    await this.$store.dispatch({
      type: "device/getAllPoints"
    });
  }
};
</script>