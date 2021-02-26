<template>
  <q-page>
    <div>
      {{res}}
    </div>
  </q-page>
</template>

<script>
import { defineComponent } from 'vue';
import FdjService from '../services/connectors/fdj/service'

export default defineComponent({
  name: 'PageIndex',
  data() {
    return {
      res: null
    }
  },
  created() {
    let fdjService = new FdjService();
    fdjService.Run();
  }
})
</script>
