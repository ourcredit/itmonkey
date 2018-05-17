<template>
  <div>
    <Card>
      <p slot="title">工作/任务信息</p>
      <Row :gutter="8" slot="extra">
        <i-col span="6">
          <Input placeholder="任务名称" v-model="params.name"/>
        </i-col>
        <i-col span="6">
          <Input placeholder="发布人昵称" v-model="params.num"/>
        </i-col>
        <i-col span="6">
          <Input placeholder="承接人昵称" v-model="params.num"/>
        </i-col>
        <i-col offset="1" span="3">
          <i-button @click="getpage" type="primary">查询</i-button>
        </i-col>
        <!-- <i-col span="3">
          <i-button @click="create" type="primary">添加</i-button>
        </i-col> -->
      </Row>
      <Table :columns="columns" border :data="jobs"></Table>
      <Page :total="totalCount" class="margin-top-10" @on-change="pageChange" @on-page-size-change="pagesizeChange" :page-size="pageSize"
        :current="currentPage"></Page>
    </Card>
  </div>
</template>
<script>
export default {
  methods: {
    pageChange(page) {
      this.$store.commit("job/setCurrentPage", page);
      this.getpage();
    },
    pagesizeChange(pagesize) {
      this.$store.commit("job/setPageSize", pagesize);
      this.getpage();
    },
    async getpage() {
      await this.$store.dispatch({
        type: "job/getAll"
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
          key: "name"
        },
        {
          title: "发布人昵称",
          key: "creatorId"
        },
          {
          title: "承接任务人昵称",
          key: "controlNum"
        },
        {
          title: "项目金额",
          key: "price"
        },
        {
          title: "一级奖金",
          key: "firstGrade"
        },
          {
          title: "二级奖金",
          key: "secondGrade"
        },
          {
          title: "三级奖金",
          key: "thirdGrade"
        },
          {
          title: "报名人数",
          key: "joinCount"
        },
          {
          title: "状态",
          key: "state"
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
    jobs() {
      return this.$store.state.job.jobs;
    },
    totalCount() {
      return this.$store.state.job.totalCount;
    },
    currentPage() {
      return this.$store.state.job.currentPage;
    },
    pageSize() {
      return this.$store.state.job.pageSize;
    }
  },
  async created() {
    this.getpage();
  }
};
</script>