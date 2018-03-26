import {
  handleActions
} from 'redux-actions'
import {
  UPDATE,
  REGISTER
} from '../types/userState'

export default handleActions({
  [UPDATE](state) {
    return { ...state,
      nickName: "十三"
    }
  },
  [REGISTER](state) {
    return {
      ...state,
      hasRegister: true
    }
  }
}, {
  user: null,
  hasRegister: false
})
