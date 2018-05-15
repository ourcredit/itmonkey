import Main from '@/views/Main.vue';
import util from '@/libs/util.js';

//title properties are localization keys.

export const loginRouter = {
    path: '/login',
    name: 'login',
    meta: {
        title: '登陆页'
    },
    component: () =>
        import ('@/views/login.vue')
};

export const page404 = {
    path: '/*',
    name: 'error-404',
    meta: {
        title: '404-未找到页面'
    },
    component: () =>
        import ('@/views/error-page/404.vue')
};

export const page403 = {
    path: '/403',
    meta: {
        title: '403 - 未授权'
    },
    name: 'error-403',
    component: () =>
        import ('@//views/error-page/403.vue')
};

export const page500 = {
    path: '/500',
    meta: {
        title: '500 - 服务器内部错误'
    },
    name: 'error-500',
    component: () =>
        import ('@/views/error-page/500.vue')
};
export const locking = {
    path: '/locking',
    name: 'locking',
    component: () =>
        import ('@/views/main-components/lockscreen/components/locking-page.vue')
};

// A route which is not displayed in the left menu
export const otherRouter = {
    path: '/',
    name: 'otherRouter',
    component: Main,
    children: [{
        path: 'setting',
        title: '商品配置',
        name: 'settings',
        permission: 'Pages.Device.Manage.Create',
        component: () =>
            import ('@/views/operators/setting.vue')
    }, {
        path: 'box',
        title: '货道管理',
        name: 'boxs',
        permission: 'Pages.Operator.Boxs',
        component: () =>
            import ('@/views/operators/box.vue')
    }]
};

// Left menu items
export const appRouter = [{
    path: '/users',
    icon: 'pinpoint',
    title: '用户管理',
    name: 'users',
    component: Main,
    children: [{
        path: 'user',
        title: '用户信息',
        name: 'pointmanage',
        // permission: '',
        component: () =>
            import ('@/views/points/index.vue')
    }, {
        path: 'pickup',
        title: '提现信息',
        name: 'pointview',
        // permission: 'Pages.Point.View',
        component: () =>
            import ('@/views/points/view.vue')
    }]
}, {
    path: '/monkeycion',
    icon: 'magnet',
    title: '猿人币交易',
    name: 'monkeycion',
    component: Main,
    children: [{
        path: 'work',
        title: '工作/任务信息',
        name: 'work',
        // permission: 'Pages.Device.Manage',
        component: () =>
            import ('@/views/devices/index.vue')
    }, {
        path: 'orderlist',
        title: '交易清单',
        name: 'orderlist',
        // permission: 'Pages.Device.Manage',
        component: () =>
            import ('@/views/devices/index.vue')
    }]
}, {
    path: '/shop',
    icon: 'record',
    title: '商城管理',
    name: 'shop',
    component: Main,
    children: [{
        path: 'product',
        title: '商品管理',
        name: 'product',
       // permission: 'Pages.Orders.OrderList',
        component: () =>
            import ('@/views/orders/index.vue')
    },{
        path: 'storeorder',
        title: '商城订单',
        name: 'storeorder',
       // permission: 'Pages.Orders.OrderList',
        component: () =>
            import ('@/views/orders/index.vue')
    }]
}, {
    path: '/serial',
    icon: 'android-list',
    title: '系列管理',
    name: 'serial',
    component: Main,
    children: [{
        path: 'logs',
        title: '日志信息',
        name: 'logs',
        permission: 'Pages.AuditLogs.Logs',
        component: () =>
            import ('@/views/auditlogs/logs.vue')
    }, {
        path: 'warns',
        title: '报警信息',
        name: 'warns',
        permission: 'Pages.AuditLogs.Warns',
        component: () =>
            import ('@/views/auditlogs/warns.vue')
    }]
}];
// All the routes defined above should be written in the routers below
export const routers = [
    loginRouter,
    otherRouter,
    locking,
    ...appRouter,
    page500,
    page403,
    page404
];