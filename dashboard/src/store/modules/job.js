import Cookies from 'js-cookie';
import Util from '@/libs/util'
import appconst from '@/libs/appconst'
const job = {
    namespaced: true,
    state: {
        jobs: [],
        totalCount: 0,
        pageSize: 10,
        currentPage: 1
    },
    mutations: {
        setPageSize(state, size) {
            state.pageSize = size;
        },
        setCurrentPage(state, page) {
            state.currentPage = page;
        }
    },
    "actions": {
        async getAll({
            state
        }, payload) {
            let page = {
                maxResultCount: state.pageSize,
                skipCount: (state.currentPage - 1) * state.pageSize,
            }
            let rep = await Util.ajax.get('/api/services/app/Job/GetPagedJobs', {
                params: page
            });
            state.jobs = [];
            state.jobs.push(...rep.data.result.items);
            state.totalCount = rep.data.result.totalCount;
        }
    }
};
export default job;