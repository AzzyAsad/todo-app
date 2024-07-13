import { toast, Bounce } from 'react-toastify';

const ToastService = {
	showSuccessToast(msg: string) {
		toast.success(msg, {
			position: "top-right",
			autoClose: 3000,
			hideProgressBar: false,
			closeOnClick: true,
			pauseOnHover: true,
			draggable: true,
			progress: undefined,
			theme: "dark",
			transition: Bounce,
		});
	},

	showErrorToast(msg: string) {
		toast.error(msg, {
			position: "top-right",
			autoClose: 3000,
			hideProgressBar: false,
			closeOnClick: true,
			pauseOnHover: true,
			draggable: true,
			progress: undefined,
			theme: "dark",
			transition: Bounce,
		});
	}
};

export default ToastService;