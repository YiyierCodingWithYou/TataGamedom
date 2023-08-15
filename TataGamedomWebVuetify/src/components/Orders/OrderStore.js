import { computed, onMounted } from 'vue';
import { useStore } from 'vuex';

export default {
    setup() {
        const store = useStore();

        const results = computed(() => store.state.results);

        const loadResults = () => {
            store.dispatch('loadResults');
        }

        onMounted(loadResults);

        return {
            results
        }
    }
}
