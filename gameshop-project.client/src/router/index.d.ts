declare module '*.vue' {
    import Vue from 'vue';
    export default Vue;
}

declare module 'vue-router' {
    import VueRouter from 'vue-router';
    const router: VueRouter;
    export default router;
}